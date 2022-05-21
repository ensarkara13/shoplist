import { requestOptions } from "../requestOptions";

export const post = async (url, value, isAuthenticated = true) => {
  const data = await fetch(
    url,
    requestOptions({ value, isAuthenticated, method: "post" })
  );
  const response = await data.json();
  return response;
};
