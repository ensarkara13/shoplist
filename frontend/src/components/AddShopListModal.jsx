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
import { useEffect, useState } from "react";
import { addCategoryBackend } from "../../apiConnection";
import { useMutation, useQueryClient } from "react-query";
import { useAuthContext } from "../contexts/authContext";
import { useNavigate } from "react-router-dom";

function AddShopListModal() {
  const [shopListName, setShopListName] = useState("");
  const [isShopping, setIsShopping] = useState(false);
  const [isFinished, setIsFinished] = useState(false);
  const { userId } = useAuthContext();
  const navigate = useNavigate();
  const { isOpen, onClose, onOpen } = useDisclosure();

  const addShopList = () => {
    const shopList = {
      name: shopListName,
      isShopping,
      isFinished,
      userId,
    };

    if (shopListName.length === 0) return;
    console.log(shopList);
    setShopListName("");
    onClose();
  };

  return (
    <>
      <Button onClick={onOpen} colorScheme={"green"}>
        Alışveriş Listesi Ekle
      </Button>
      <Modal isOpen={isOpen} onClose={onClose}>
        <ModalOverlay />
        <ModalContent>
          <ModalHeader>Liste Ekle</ModalHeader>
          <ModalCloseButton />
          <ModalBody>
            <FormControl>
              <FormLabel>Liste Adı</FormLabel>
              <Input
                placeholder="Liste Adı"
                name="name"
                required
                value={shopListName}
                onChange={(e) => setShopListName(e.target.value)}
              />
            </FormControl>
          </ModalBody>
          <ModalFooter>
            <Button colorScheme="blue" mr={3} onClick={addShopList}>
              Kaydet
            </Button>
            <Button onClick={onClose}>Geri Dön</Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </>
  );
}

export default AddShopListModal;
