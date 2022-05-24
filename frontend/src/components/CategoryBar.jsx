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
  TagCloseButton,
  TagRightIcon,
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
      deleteMutation.mutate(id);
    }
  };

  return (
    <>
      <Box
        backgroundColor={"blue.800"}
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
        <SimpleGrid columns={2} spacing={5} m={"2"}>
          <Box>
            <Tag
              colorScheme={"red"}
              as="button"
              onClick={() => handleDelete(category.id)}
            >
              <TagLabel>Sil</TagLabel>
            </Tag>
          </Box>
          <Box>
            <Tag colorScheme={""} as="button">
              <TagLabel>Düzenle</TagLabel>
            </Tag>
          </Box>
        </SimpleGrid>
      </Box>
    </>

    // <Box textAlign={"center"} m={"3"}>
    //   <Box backgroundColor={"green.500"} p={"3"}>
    //     <h2>
    //       <Box>
    //         <Box
    //           flex="1"
    //           textAlign="left"
    //           // onClick={() => getProducts(category.id)}
    //         >
    //           {category.name}
    //         </Box>
    //         <Box
    //           ms={"2"}
    //           backgroundColor={"red.300"}
    //           p={"2"}
    //           onClick={() => handleDelete(category.id)}
    //         >
    //           Sil
    //         </Box>
    //         <Box backgroundColor={"blue.300"} p={"2"} ms={"2"}>
    //           Düzenle
    //         </Box>
    //       </Box>
    //     </h2>
    //   </Box>
    // </Box>
  );
}

export default CategoryBar;
