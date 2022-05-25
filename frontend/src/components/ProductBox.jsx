import {
  Button,
  Table,
  Thead,
  Tbody,
  Tr,
  Th,
  Td,
  TableContainer,
  Flex,
  Spinner,
} from "@chakra-ui/react";
import { useNavigate } from "react-router-dom";
import { useAuthContext } from "../contexts/authContext";
import { useMutation, useQueryClient, useQuery } from "react-query";
import { deleteProductBackend, getProductsBackend } from "../../apiConnection";
import { useShopListContext } from "../contexts/shopListContext";
import { useEffect } from "react";

function ProductBox() {
  const { isAdmin } = useAuthContext();
  const { setProducts, products } = useShopListContext();
  const { data: productData, isLoading: isProductLoading } = useQuery(
    "admin:products",
    getProductsBackend
  );
  const queryClient = useQueryClient();
  const deleteMutation = useMutation(deleteProductBackend, {
    onSuccess: () => queryClient.invalidateQueries("admin:products"),
  });

  useEffect(() => {
    setProducts(productData);
  }, [productData]);

  const handleDelete = async (id) => {
    if (confirm("Silmek istediğinize emin misiniz?")) {
      deleteMutation.mutate(id);
    }
  };

  return (
    <>
      {isProductLoading && (
        <Flex align={"center"} m={"5"}>
          <Spinner />
        </Flex>
      )}
      <TableContainer width={"100%"} mx={"3"}>
        <Table>
          <Thead>
            <Tr>
              <Th>Ürün Id</Th>
              <Th>Ürün Adı</Th>
              <Th>Oluşturma Tarihi</Th>
              {isAdmin && <Th></Th>}
            </Tr>
          </Thead>
          <Tbody>
            {products?.length > 0 &&
              products.map((product, index) => {
                return (
                  <Tr key={index}>
                    <Td>{product.id}</Td>
                    <Td>{product.name}</Td>
                    <Td>{product.createdAt}</Td>
                    {isAdmin && (
                      <Td>
                        <Button colorScheme={"blue"} mx={"1"}>
                          Düzenle
                        </Button>
                        <Button
                          colorScheme={"red"}
                          mx={"1"}
                          onClick={() => handleDelete(product.id)}
                        >
                          Sil
                        </Button>
                      </Td>
                    )}
                  </Tr>
                );
              })}
          </Tbody>
        </Table>
      </TableContainer>
    </>
  );
}

export default ProductBox;
