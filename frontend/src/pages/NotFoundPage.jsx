import { Flex, Heading } from "@chakra-ui/react";

function NotFound() {
  return (
    <Flex align={"center"} justifyContent={"center"} my={40}>
      <Heading as={"h1"} size={"xl"}>
        Not Found
      </Heading>
    </Flex>
  );
}

export default NotFound;
