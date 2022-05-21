import {
  Box,
  Button,
  Flex,
  FormControl,
  FormLabel,
  Heading,
  Input,
} from "@chakra-ui/react";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuthContext } from "../../../contexts/authContext";
import { validationSchema } from "./validations";

const initialInputs = {
  firstName: "",
  lastName: "",
  email: "",
  password: "",
  confirmPassword: "",
};

function RegisterPage() {
  const [form, setForm] = useState(initialInputs);
  const [validationErrors, setValidationErrors] = useState([]);
  const { register } = useAuthContext();

  const navigate = useNavigate();

  const handleChange = (e) => {
    setForm((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    validationSchema
      .validate(form, { abortEarly: false })
      .then(async (res) => {
        await register(res);
        navigate("/");
      })
      .catch((err) => {
        setValidationErrors(err.errors);
      });
  };

  return (
    <Flex align={"center"} justifyContent={"center"} width={"full"}>
      <Box pt={"10"}>
        <Box textAlign={"center"}>
          <Heading>Kaydol</Heading>
        </Box>
        <Box my={"5"} textAlign="left">
          <form onSubmit={handleSubmit}>
            <FormControl>
              <FormLabel>İsim</FormLabel>
              <Input
                id="firstName"
                name="firstName"
                type={"text"}
                // pattern="^[A-Za-zğüşçİ]+$"
                required
                value={form.firstName}
                onChange={handleChange}
              />
            </FormControl>
            <FormControl>
              <FormLabel>Soyisim</FormLabel>
              <Input
                id="lastName"
                name="lastName"
                type={"text"}
                // pattern="^[A-Za-zğüşçİ]+$"
                required
                value={form.lastName}
                onChange={handleChange}
              />
            </FormControl>
            <FormControl>
              <FormLabel>E-Posta</FormLabel>
              <Input
                id="email"
                name="email"
                type={"email"}
                required
                value={form.email}
                onChange={handleChange}
              />
            </FormControl>
            <FormControl>
              <FormLabel>Şifre</FormLabel>
              <Input
                id="password"
                name="password"
                type={"password"}
                // pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,}$"
                minLength={"8"}
                required
                value={form.password}
                onChange={handleChange}
              />
            </FormControl>
            <FormControl>
              <FormLabel>Şifre Tekrar</FormLabel>
              <Input
                id="confirmPassword"
                name="confirmPassword"
                type={"password"}
                // pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,}$"
                minLength={"8"}
                required
                value={form.confirmPassword}
                onChange={handleChange}
              />
            </FormControl>
            <Button colorScheme={"blue"} mt={"4"} w={"full"} type="submit">
              Kaydol
            </Button>
          </form>
        </Box>
      </Box>
    </Flex>
  );
}

export default RegisterPage;
