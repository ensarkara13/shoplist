import {
  Box,
  Button,
  Flex,
  FormControl,
  FormLabel,
  Heading,
  Input,
  Text,
} from "@chakra-ui/react";
import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuthContext } from "../../../contexts/authContext";
import { validationSchema } from "./validations";

const initialInputs = {
  email: "",
  password: "",
};

function LoginPage() {
  const [form, setForm] = useState(initialInputs);
  const [validationErrors, setValidationErrors] = useState([]);
  const { login } = useAuthContext();
  const navigate = useNavigate();

  const handleChange = (e) => {
    setForm((prev) => ({ ...prev, [e.target.name]: e.target.value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    validationSchema
      .validate(form, { abortEarly: false })
      .then(async (res) => {
        await login(res);
        navigate("dashboard");
      })
      .catch(({ errors }) => {
        setValidationErrors(errors);
      });
  };
  return (
    <>
      <Flex align={"center"} justifyContent={"center"} width={"full"}>
        <Box pt={"10"}>
          <Box textAlign={"center"}>
            <Heading>Giriş Yap</Heading>
          </Box>

          <Box my={"5"} textAlign={"left"}>
            <form onSubmit={handleSubmit}>
              <FormControl>
                <FormLabel>E-Mail</FormLabel>
                <Input
                  id="email"
                  name="email"
                  type={"email"}
                  required
                  value={form.email}
                  onChange={handleChange}
                />
              </FormControl>
              <FormControl mt={"4"}>
                <FormLabel>Şifre</FormLabel>
                <Input
                  id="password"
                  name="password"
                  type={"password"}
                  pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,}$"
                  minLength="8"
                  required
                  value={form.password}
                  onChange={handleChange}
                />
              </FormControl>

              <Button colorScheme={"blue"} mt={"4"} w={"full"} type="submit">
                Giriş Yap
              </Button>
            </form>
          </Box>
          <Box my={"5"} textAlign={"left"}>
            Hesabınız yok mu?
            <Text color={"blue.900"}>
              <Link to={"/register"}>Kaydolun</Link>
            </Text>
          </Box>
        </Box>
      </Flex>
    </>
  );
}

export default LoginPage;
