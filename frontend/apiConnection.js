import axios from "axios";

axios.interceptors.request.use(function (config) {
  const { origin } = new URL(config.url);

  const allowedOrigins = [import.meta.env.VITE_BASE_ENDPOINT];
  const accessToken = document.cookie;

  if (allowedOrigins.includes(origin)) {
    config.headers.authorization = accessToken;
  }

  return config;
});

const baseEndpoint = `${import.meta.env.VITE_BASE_ENDPOINT}`;
const authEndpoint = `${baseEndpoint}/auth`;
const categoryEndpoint = `${baseEndpoint}/categories`;
const productEndpoint = `${baseEndpoint}/products`;
const shopListEndpoint = `${baseEndpoint}/shoplists`;
const shopListProductEndpoint = `${baseEndpoint}/shoplistproducts`;

// AUTH

