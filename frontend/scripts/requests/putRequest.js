import { requestOptions } from "../requestOptions";

export const putRequest = async (url, value, isAuthenticated = true) => {
  const data = await fetch(
    url,
    requestOptions({ value, isAuthenticated, method: "put" })
  );
  const response = await data.json();
  return response;
};
