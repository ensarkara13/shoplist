import { get, post } from "./scripts/requests/index";

const baseEndpoint = `${import.meta.env.VITE_BASE_ENDPOINT}`;
const authEndpoint = `${baseEndpoint}/auth`;
const categoryEndpoint = `${baseEndpoint}/categories`;
const productEndpoint = `${baseEndpoint}/products`;
const shopListEndpoint = `${baseEndpoint}/shoplists`;
const shopListProductEndpoint = `${baseEndpoint}/shoplistproducts`;

// AUTH
export const registerBackend = async (user) => {
  return await post(`${authEndpoint}/register`, user, false);
};

export const loginBackend = async (user) => {
  return await post(`${authEndpoint}/login`, user, false);
};

// GET
export const getCategoriesBackend = async () => {
  return await get(categoryEndpoint);
};

export const getProductsBackend = async () => {
  return await get(productEndpoint);
};

export const getShopListsBackend = async () => {
  return await get(shopListEndpoint);
};

export const getShopListProductsBackend = async (userId) => {
  return await get(`${shopListProductEndpoint}/${userId}`);
};
