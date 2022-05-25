import {
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalFooter,
  ModalBody,
  ModalCloseButton,
  Button,
  useDisclosure,
  FormControl,
  FormLabel,
  Input,
  Select,
} from "@chakra-ui/react";
import { useState } from "react";
import { useMutation, useQueryClient } from "react-query";
import { addProductBackend } from "../../apiConnection";
import { useShopListContext } from "../contexts/shopListContext";

const initialProduct = { name: "", categoryId: null };

function AddProductModal() {
  const [product, setProduct] = useState(initialProduct);
  const { categories } = useShopListContext();
  const { isOpen, onOpen, onClose } = useDisclosure();
  const queryClient = useQueryClient();
  const addMutation = useMutation(addProductBackend, {
    onSuccess: () => queryClient.invalidateQueries("admin:products"),
  });

  const handleChange = (e) => {
    setProduct((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  };

  const addProduct = () => {
    if (product.categoryId === null || product.name.length <= 0) return;
    product.categoryId = parseInt(product.categoryId);
    console.log(product);
    addMutation.mutate(product, {
      onSuccess: () => console.log("Ürün başarılı"),
      onError: () => console.log("Hata"),
    });
    setProduct(initialProduct);
    onClose();
  };

  return (
    <>
      <Button onClick={onOpen} colorScheme={"green"} mx={1}>
        Ürün Ekle
      </Button>
      <Modal isOpen={isOpen} onClose={onClose}>
        <ModalOverlay />
        <ModalContent>
          <ModalHeader>Ürün Ekle</ModalHeader>
          <ModalCloseButton />
          <ModalBody>
            <FormControl>
              <FormLabel>Kategori</FormLabel>
              <Select
                placeholder="Kategori Seçiniz"
                name="categoryId"
                onChange={handleChange}
              >
                {categories &&
                  categories.map((category, index) => {
                    return (
                      <option value={category.id} key={index}>
                        {category.name}
                      </option>
                    );
                  })}
              </Select>
            </FormControl>
            <FormControl mt={"2"}>
              <FormLabel>Ürün Adı</FormLabel>
              <Input
                placeholder="Ürün Adı"
                name="name"
                value={product.name}
                onChange={handleChange}
              />
            </FormControl>
          </ModalBody>
          <ModalFooter>
            <Button colorScheme="blue" mr={3} onClick={addProduct}>
              Kaydet
            </Button>
            <Button onClick={onClose}>Geri Dön</Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </>
  );
}

export default AddProductModal;
