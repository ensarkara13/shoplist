import { Box, Button, Flex, Text, Heading, Grid } from "@chakra-ui/react";
import { useAuthContext } from "../contexts/authContext";
import CategoryBar from "../components/CategoryBar";

function DashboardPage() {
  const { isAdmin } = useAuthContext();

  return (
    <>
      {isAdmin && (
        <Box m={2} p={2}>
          <Button colorScheme={"green"} mx={1}>
            Kategori Ekle
          </Button>
          <Button colorScheme={"green"} mx={1}>
            Ürün Ekle
          </Button>
        </Box>
      )}

      <Flex align={"center"}>
        <Box m={5}>
          <Heading as={"h3"} size={"lg"} my={"4"}>
            Kategoriler
          </Heading>
          {categories?.length > 0 &&
            categories.map((category, index) => {
              return <CategoryBar key={index} category={category} />;
            })}
        </Box>
        <Box m={5}>
          <Heading as={"h3"} size={"lg"} m={"3"}>
            Ürünler
          </Heading>
          <Grid templateColumns={"repeat(4, 1fr)"} gap={4}>
            {/* {products?.length > 0 &&
              products.map((product, index) => {
                return <ProductBox key={index} product={product} />;
              })} */}
          </Grid>
        </Box>
      </Flex>
    </>
  );
}

export default DashboardPage;
