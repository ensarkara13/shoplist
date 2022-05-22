import { createContext, useContext } from "react";

const ShopListContext = createContext();

export const ShopListProvider = ({ children }) => {
  const values = {};

  return (
    <ShopListContext.Provider value={values}>
      {children}
    </ShopListContext.Provider>
  );
};

export const useShopListContext = () => useContext(ShopListContext);
