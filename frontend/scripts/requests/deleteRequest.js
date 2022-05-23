import { requestOptions } from "../requestOptions";

export const deleteRequest = async (url, isAuthenticated = true) => {
  const data = await fetch(
    url,
    requestOptions({ value, isAuthenticated, method: "delete" })
  );
  const response = await data.json();
  return response;
};
