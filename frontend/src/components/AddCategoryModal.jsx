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
} from "@chakra-ui/react";
import { useState } from "react";
import { addCategoryBackend } from "../../apiConnection";
import { useMutation, useQueryClient } from "react-query";

const initialCategory = { name: "" };

function AddCategoryModal() {
  const [category, setCategory] = useState(initialCategory);
  const { isOpen, onOpen, onClose } = useDisclosure();
  const queryClient = useQueryClient();
  const addMutation = useMutation(addCategoryBackend, {
    onSuccess: () => queryClient.invalidateQueries("admin:categories"),
  });

  const handleChange = (e) => {
    setCategory({ [e.target.name]: e.target.value });
  };

  const addCategory = () => {
    if (category.name.length <= 0) return;
    addMutation.mutate(category, {
      onSuccess: () => {
        console.log("Ekleme başarılı");
      },
      onError: (error) => {
        console.log(error);
      },
    });

    setCategory(initialCategory);
    onClose();
  };

  return (
    <>
      <Button onClick={onOpen} colorScheme={"green"} mx={1}>
        Kategori Ekle
      </Button>
      <Modal isOpen={isOpen} onClose={onClose}>
        <ModalOverlay />
        <ModalContent>
          <ModalHeader>Kategori Ekle</ModalHeader>
          <ModalCloseButton />
          <ModalBody>
            <FormControl>
              <FormLabel>Kategori Adı</FormLabel>
              <Input
                placeholder="Kategori Adı"
                name="name"
                value={category.name}
                onChange={handleChange}
                required
              />
            </FormControl>
          </ModalBody>
          <ModalFooter>
            <Button colorScheme="blue" mr={3} onClick={addCategory}>
              Kaydet
            </Button>
            <Button onClick={onClose}>Geri Dön</Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </>
  );
}

export default AddCategoryModal;
