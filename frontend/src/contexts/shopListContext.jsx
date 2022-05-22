import {
  createContext,
  useCallback,
  useContext,
  useEffect,
  useMemo,
  useState,
} from "react";
import { getCategoriesBackend } from "../../apiConnection";

const ShopListContext = createContext();

export const ShopListProvider = ({ children }) => {
  const [categories, setCategories] = useState([]);
  const [products, setProducts] = useState([]);

  const getCategories = useMemo(() => {
    return async () => {
      const categoryResponse = await getCategoriesBackend();
      setCategories(categoryResponse);
    };
  }, [categories]);

  useEffect(() => {
    getCategories();
  }, []);

  const values = {
    categories,
    products,
    setProducts,
    setCategories,
  };

  return (
    <ShopListContext.Provider value={values}>
      {children}
    </ShopListContext.Provider>
  );
};

export const useShopListContext = () => useContext(ShopListContext);
