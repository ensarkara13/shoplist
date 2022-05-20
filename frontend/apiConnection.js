const baseEndpoint = `${import.meta.env.VITE_BASE_ENDPOINT}`;
const authEndpoint = `${baseEndpoint}/auth`;
const categoryEndpoint = `${baseEndpoint}/categories`;
const productEndpoint = `${baseEndpoint}/products`;
const shopListEndpoint = `${baseEndpoint}/shoplists`;
const shopListProductEndpoint = `${baseEndpoint}/shoplistproducts`;

const postRequestOptions = (value, isAuthenticated = false) => {
  const config = {
    method: "post",
    body: JSON.stringify(value),
    headers: {
      "Content-Type": "application/json",
    },
  };

  if (isAuthenticated) {
    config.headers["Authorization"] = `Bearer ${localStorage.getItem(
      "access-token"
    )}`;
  }

  return config;
};
// AUTH
export const registerBackend = async (user) => {
  const data = await fetch(
    `${authEndpoint}/register`,
    postRequestOptions(user)
  );
  const response = data.json();
  return response;
};

export const loginBackend = async (user) => {
  const data = await fetch(`${authEndpoint}/login`, postRequestOptions(user));
  const response = data.json();
  return response;
};
