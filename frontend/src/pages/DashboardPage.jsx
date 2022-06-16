import { Box, Flex, Heading, Spinner, Spacer } from "@chakra-ui/react";
import { useAuthContext } from "../contexts/authContext";
import CategoryBar from "../components/CategoryBar";
import ProductBox from "../components/ProductBox";
import { useShopListContext } from "../contexts/shopListContext";
import AddCategoryModal from "../components/AddCategoryModal";
import AddProductModal from "../components/AddProductModal";
import { useQuery } from "react-query";
import { getCategoriesWithProductsBackend } from "../../apiConnection";
import { useEffect } from "react";

function DashboardPage() {
  const { isAdmin, setCurrentLocation } = useAuthContext();
  const { setCategories, setProducts, categories } = useShopListContext();
  const { data: categoryData, isLoading: isCategoryLoading } = useQuery(
    "admin:categories",
    getCategoriesWithProductsBackend
  );

  const getProducts = () => {
    const categoryProducts = [];
    if (!isCategoryLoading) {
      for (let category of categoryData) {
        category.products.forEach((product) => categoryProducts.push(product));
      }
    }
    return categoryProducts;
  };

  useEffect(() => {
    setCurrentLocation(window.location.pathname);
    localStorage.setItem("current-location", window.location.pathname);

    // setCategories(categoryData);
    // setProducts(getProducts());
  }, []);

  useEffect(() => {
    setCategories(categoryData);
    setProducts(getProducts());
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
          {isCategoryLoading ? (
            <Flex align={"center"} m={"5"}>
              <Spinner />
            </Flex>
          ) : (
            categories?.length > 0 &&
            categories.map((category, index) => {
              return <CategoryBar key={index} category={category} />;
            })
          )}
        </Box>
        <Spacer />
        {isCategoryLoading ? (
          <Flex align={"center"} m={"5"}>
            <Spinner />
          </Flex>
        ) : (
          <ProductBox />
        )}
        <Spacer />
      </Flex>
    </>
  );
}

export default DashboardPage;
