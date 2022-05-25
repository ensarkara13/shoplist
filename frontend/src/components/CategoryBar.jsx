import {
  Accordion,
  AccordionItem,
  AccordionButton,
  Box,
  Button,
  Flex,
  SimpleGrid,
  Tag,
  TagLabel,
} from "@chakra-ui/react";
import { useQueryClient, useMutation } from "react-query";
import { deleteCategoryBackend } from "../../apiConnection";
import { useAuthContext } from "../contexts/authContext";

function CategoryBar({ category }) {
  const { isAdmin } = useAuthContext();
  const queryClient = useQueryClient();
  const deleteMutation = useMutation(deleteCategoryBackend, {
    onSuccess: () => queryClient.invalidateQueries("admin:categories"),
  });

  const handleDelete = (id) => {
    if (confirm("Silmek istediğinize emin misiniz?")) {
      deleteMutation.mutate(id);
    }
  };

  return (
    <>
      <Box
        width={"200px"}
        borderRadius={"10px"}
        textAlign={"center"}
        my={"3"}
        p={"2"}
      >
        <Box
          width={"100%"}
          backgroundColor={"blue.400"}
          borderRadius={"5px"}
          height="30px"
        >
          {category.name}
        </Box>
        {isAdmin && (
          <SimpleGrid columns={2} spacing={5} m={"2"}>
            <Box>
              <Button colorScheme={"blue"} size={"sm"}>
                Düzenle
              </Button>
            </Box>
            <Box>
              <Button
                size={"sm"}
                colorScheme={"red"}
                onClick={() => handleDelete(category.id)}
              >
                Sil
              </Button>
            </Box>
          </SimpleGrid>
        )}
      </Box>
    </>
  );
}

export default CategoryBar;
