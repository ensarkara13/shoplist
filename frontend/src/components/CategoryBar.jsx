import {
  Accordion,
  AccordionItem,
  AccordionButton,
  Box,
  Button,
} from "@chakra-ui/react";
import { useQueryClient, useMutation } from "react-query";
import { deleteCategoryBackend } from "../../apiConnection";

function CategoryBar({ category }) {
  const queryClient = useQueryClient();
  const deleteMutation = useMutation(deleteCategoryBackend, {
    onSuccess: () => queryClient.invalidateQueries("admin:categories"),
  });

  const handleDelete = (id) => {
    if (confirm("Silmek istediğinize emin misiniz?")) {
      deleteMutation.mutate(id, {
        onSuccess: () => console.log("Success"),
      });
    }
  };

  return (
    <Accordion>
      <AccordionItem backgroundColor={"green.500"}>
        <h2>
          <AccordionButton>
            <Box
              flex="1"
              textAlign="left"
              // onClick={() => getProducts(category.id)}
            >
              {category.name}
            </Box>
            <Box
              ms={"2"}
              backgroundColor={"red.300"}
              p={"2"}
              onClick={() => handleDelete(category.id)}
            >
              Sil
            </Box>
            <Box backgroundColor={"blue.300"} p={"2"} ms={"2"}>
              Düzenle
            </Box>
          </AccordionButton>
        </h2>
      </AccordionItem>
    </Accordion>
  );
}

export default CategoryBar;
