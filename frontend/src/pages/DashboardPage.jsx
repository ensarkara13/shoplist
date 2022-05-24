import {
  Box,
  Button,
  Flex,
  Text,
  Heading,
  Grid,
  Spinner,
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
  const { setCategories, setProducts } = useShopListContext();
  const { data: categoryData, isLoading: isCategoryLoading } = useQuery(
    "admin:categories",
    getCategoriesBackend
  );
  const { data: productData, isLoading: isProductLoading } = useQuery(
    "admin:products",
    getProductsBackend
  );

  useEffect(() => {
    setCategories(categoryData);
  }, [categoryData]);


  return (
    <>
      {isAdmin && (
        <Box m={2} p={2}>
          <AddCategoryModal />
          <AddProductModal />
        </Box>
      )}

      <Flex align={"center"}>
        <Box m={5}>
          <Heading as={"h3"} size={"lg"} my={"4"}>
            Kategoriler
          </Heading>
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
        {isProductLoading && (
          <Flex align={"center"} m={"5"}>
            <Spinner />
          </Flex>
        )}
        <Box m={5}>
          <Heading as={"h3"} size={"lg"} m={"3"}>
            Ürünler
          </Heading>
          <Grid templateColumns={"repeat(4, 1fr)"} gap={4}>
            {productData?.length > 0 &&
              productData.map((product, index) => {
                return <ProductBox key={index} product={product} />;
              })}
          </Grid>
        </Box>
      </Flex>
    </>
  );
}

export default DashboardPage;
