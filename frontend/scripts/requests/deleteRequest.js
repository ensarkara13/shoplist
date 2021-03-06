import { requestOptions } from "../requestOptions";

export const deleteRequest = async (url, isAuthenticated = true) => {
  const data = await fetch(
    url,
    requestOptions({ isAuthenticated, method: "delete" })
  );
  // const response = await data.json();
  // return response;
};
