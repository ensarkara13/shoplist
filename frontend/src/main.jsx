import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import "./index.css";
import { ChakraProvider } from "@chakra-ui/react";
import { AuthProvider } from "./contexts/authContext";
import { ShopListProvider } from "./contexts/shopListContext";

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <ChakraProvider>
      <AuthProvider>
        <ShopListProvider>
          <App />
        </ShopListProvider>
      </AuthProvider>
    </ChakraProvider>
  </React.StrictMode>
);
