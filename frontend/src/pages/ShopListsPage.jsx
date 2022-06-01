import { Box, Button, Container, Heading, SimpleGrid } from "@chakra-ui/react";
import { useEffect } from "react";
import {} from "react-query";
import {} from "react-router-dom";
import {} from "../../apiConnection";
import AddShopListModal from "../components/AddShopListModal";
import ShopList from "../components/ShopList";
import { useAuthContext } from "../contexts/authContext";

function ShopListsPage() {
  const { setCurrentLocation } = useAuthContext();

  useEffect(() => {
    setCurrentLocation(window.location.pathname);
    localStorage.setItem("current-location", window.location.pathname);
  }, []);

  return (
    <Container minW={"100%"} p={"3"}>
      <Heading>Listelerim</Heading>
      <Box my={"4"}>
        <AddShopListModal />
      </Box>
      <SimpleGrid minChildWidth={"150px"} spacing={"30px"} mt={"30px"}>
        <ShopList />
      </SimpleGrid>
    </Container>
  );
}

export default ShopListsPage;
