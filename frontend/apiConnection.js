import { requestOptions } from "./scripts/requestOptions";
import {
  getRequest,
  postRequest,
  putRequest,
  deleteRequest,
} from "./scripts/requests/index";

const baseEndpoint = `${import.meta.env.VITE_BASE_ENDPOINT}`;
const authEndpoint = `${baseEndpoint}/auth`;
const categoryEndpoint = `${baseEndpoint}/categories`;
const productEndpoint = `${baseEndpoint}/products`;
const shopListEndpoint = `${baseEndpoint}/shoplists`;
const shopListProductEndpoint = `${baseEndpoint}/shoplistproducts`;

// AUTH
export const registerBackend = async (user) => {
  // return await postRequest(`${authEndpoint}/register`, user, false);
  const response = await fetch(
    `${authEndpoint}/register`,
    requestOptions({ method: "post", value: user })
  );
  return await response.json();
};

export const loginBackend = async (user) => {
  // return await postRequest(`${authEndpoint}/login`, user, false);
  const response = await fetch(
    `${authEndpoint}/login`,
    requestOptions({ method: "post", value: user })
  );
  return await response.json();
};

// GET
export const getCategoriesBackend = async () => {
  return await getRequest(categoryEndpoint);
};

export const getProductsBackend = async () => {
  return await getRequest(productEndpoint);
};

export const getProductsByCategoryBackend = async (categoryId) => {
  return await getRequest(`${productEndpoint}?category=${categoryId}`);
};

export const getShopListsBackend = async () => {
  return await getRequest(shopListEndpoint);
};

export const getShopListProductsBackend = async (userId) => {
  return await getRequest(`${shopListProductEndpoint}/${userId}`);
};

// ADD
export const addCategoryBackend = async (category) => {
  await postRequest(categoryEndpoint, category);
};

export const addProductBackend = async (product) => {
  await postRequest(productEndpoint, product);
};

export const addShopListBackend = async (shopList) => {
  await postRequest(shopListEndpoint, shopList);
};

export const addShopListProductBackend = async (shopListProduct) => {
  await postRequest(shopListProductEndpoint, shopListProduct);
};

// UPDATE
export const updateCategoryBackend = async (categoryId, category) => {
  await putRequest(`${categoryEndpoint}/${categoryId}`, category);
};

// DELETE
export const deleteCategoryBackend = async (categoryId) => {
  await deleteRequest(`${categoryEndpoint}/${categoryId}`);
};
