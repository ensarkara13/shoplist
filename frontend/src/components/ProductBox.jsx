import { Box, Button } from "@chakra-ui/react";
import { useNavigate } from "react-router-dom";
import { useAuthContext } from "../contexts/authContext";
import { useMutation, useQueryClient } from "react-query";
import { deleteProductBackend } from "../../apiConnection";

function ProductBox({ product }) {
  const { isAdmin } = useAuthContext();
  const queryClient = useQueryClient();
  const deleteMutation = useMutation(deleteProductBackend, {
    onSuccess: () => queryClient.invalidateQueries("admin:products"),
  });

  const handleDelete = async (id) => {
    if (confirm("Silmek istediğinize emin misiniz?")) {
      deleteMutation.mutate(id);
    }
  };

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
            onClick={() => handleDelete(product.id)}
          >
            Sil
          </Button>
        </>
      )}
      {!isAdmin && (
        <Button colorScheme={"blue"} mx={1}>
          Ekle
        </Button>
      )}
    </Box>
  );
}

export default ProductBox;
