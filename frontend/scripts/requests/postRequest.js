import { requestOptions } from "../requestOptions";

export const postRequest = async (url, value, isAuthenticated = true) => {
  const data = await fetch(
    url,
    requestOptions({ value, isAuthenticated, method: "post" })
  );
  // const response = await data.json();
  // return response;
};
