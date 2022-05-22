import {
  Accordion,
  AccordionItem,
  AccordionButton,
  Box,
} from "@chakra-ui/react";
import { getProductsByCategoryBackend } from "../../apiConnection";
import { useShopListContext } from "../contexts/shopListContext";

function CategoryBar({ category }) {
  const { setProducts } = useShopListContext();

  const getProducts = async (id) => {
    const productsResponse = await getProductsByCategoryBackend(id);
    console.log(productsResponse);
    setProducts(productsResponse);
  };

  return (
    <Accordion>
      <AccordionItem backgroundColor={"blue.500"}>
        <h2>
          <AccordionButton>
            <Box
              flex="1"
              textAlign="left"
              onClick={() => getProducts(category.id)}
            >
              {category.name}
            </Box>
          </AccordionButton>
        </h2>
      </AccordionItem>
    </Accordion>
  );
}

export default CategoryBar;
