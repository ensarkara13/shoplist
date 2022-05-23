import { Box, Button } from "@chakra-ui/react";
import { useNavigate } from "react-router-dom";
import { useAuthContext } from "../contexts/authContext";

function ProductBox({ product }) {
  const { isAdmin } = useAuthContext();

  // const handleDelete = async (id) => {
  //   if (confirm("Silmek istediğinize emin misiniz?")) {
  //     navigate("/home");
  //   }
  // };

  return (
    <Box m={3} backgroundColor={"green.500"} borderRadius={5} p={5}>
      <Box p={2}>{product.name}</Box>
      {isAdmin && (
        <>
          <Button mx={1} colorScheme={"blue"}>
            Düzenle
          </Button>
          <Button
            colorScheme={"red"}
            mx={1}
            // onClick={() => handleDelete(product.id)}
          >
            Sil
          </Button>
        </>
      )}
      {!isAdmin && (
        <Button color={"blue.400"} mx={1}>
          Ekle
        </Button>
      )}
    </Box>
  );
}

export default ProductBox;
