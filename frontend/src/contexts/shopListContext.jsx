import { createContext, useContext, useState } from "react";

const ShopListContext = createContext();

export const ShopListProvider = ({ children }) => {
  const [categories, setCategories] = useState([]);
  const [products, setProducts] = useState([]);

  const values = {
    categories,
    setCategories,
    products,
    setProducts,
  };

  return (
    <ShopListContext.Provider value={values}>
      {children}
    </ShopListContext.Provider>
  );
};

export const useShopListContext = () => useContext(ShopListContext);
