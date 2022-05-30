import {
  Box,
  Flex,
  Heading,
  Spinner,
  Spacer,
} from "@chakra-ui/react";
import { useAuthContext } from "../contexts/authContext";
import CategoryBar from "../components/CategoryBar";
import ProductBox from "../components/ProductBox";
import { useShopListContext } from "../contexts/shopListContext";
import AddCategoryModal from "../components/AddCategoryModal";
import AddProductModal from "../components/AddProductModal";
import { useQuery } from "react-query";
import { getCategoriesBackend, getProductsBackend } from "../../apiConnection";
import { useEffect } from "react";

function DashboardPage() {
  const { isAdmin } = useAuthContext();
  const { setCategories } = useShopListContext();
  const { data: categoryData, isLoading: isCategoryLoading } = useQuery(
    "admin:categories",
    getCategoriesBackend
  );

  useEffect(() => {
    setCategories(categoryData);
  }, [categoryData]);

  return (
    <>
      <Flex>
        <Box>
          <Heading as={"h1"} size={"lg"} m={"4"}>
            Kategoriler
          </Heading>
        </Box>
        <Spacer />
        <Box>
          <Heading as={"h1"} size={"lg"} m={"4"}>
            Ürünler
          </Heading>
        </Box>
        <Spacer />
        <Spacer />
      </Flex>

      {isAdmin && (
        <Box m={2} p={2}>
          <AddCategoryModal />
          <AddProductModal />
        </Box>
      )}

      <Flex>
        <Box m={"5"}>
          {isCategoryLoading && (
            <Flex align={"center"} m={"5"}>
              <Spinner />
            </Flex>
          )}
          {categoryData?.length > 0 &&
            categoryData.map((category, index) => {
              return <CategoryBar key={index} category={category} />;
            })}
        </Box>
        <Spacer />
        <ProductBox />
        <Spacer />
      </Flex>
    </>
  );
}

export default DashboardPage;
