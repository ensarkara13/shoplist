import { requestOptions } from "../requestOptions";

export const get = async (url, value, isAuthenticated = true) => {
  const data = await fetch(
    url,
    requestOptions({ value, isAuthenticated, method: "get" })
  );
  const response = await data.json();
  return response;
};
