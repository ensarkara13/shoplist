import { requestOptions } from "../requestOptions";

export const getRequest = async (url, isAuthenticated = true) => {
  const data = await fetch(
    url,
    requestOptions({ isAuthenticated, method: "get" })
  );
  const response = await data.json();
  return response;
};
