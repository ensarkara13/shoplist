import { createContext, useContext, useEffect, useState } from "react";
import { loginBackend, registerBackend } from "../../apiConnection";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [isAdmin, setIsAdmin] = useState(false);
  const [userId, setUserId] = useState(null);
  const [currentLocation, setCurrentLocation] = useState("/");

  console.log(currentLocation);

  useEffect(() => {
    localStorage.setItem("chakra-ui-color-mode", "dark");
  }, []);

  useEffect(() => {
    const id = JSON.parse(localStorage.getItem("user-id"));
    if (id > 0) {
      setIsLoggedIn(true);
      setUserId(id);

      const role = localStorage.getItem("user-role");
      setIsAdmin(role === "Admin" ? true : false);
      setCurrentLocation(localStorage.getItem("current-location"));
    }
  });

  const register = async ({ firstName, lastName, email, password }) => {
    const user = { firstName, lastName, email, password };
    await registerBackend(user);
  };

  const login = async (user) => {
    const { id, role, accessToken, message, errorMessages } =
      await loginBackend(user);

    if (message != null || errorMessages != null) {
      console.log(`message: ${message}`);
      console.log(`error messages: ${errorMessages}`);
    }

    if (id === undefined || role === undefined || accessToken === undefined)
      return;

    localStorage.setItem("access-token", accessToken);
    localStorage.setItem("user-role", role);
    localStorage.setItem("user-id", id);

    setIsLoggedIn(true);
    setUserId(id);
    setIsAdmin(role === "Admin" ? true : false);
  };

  const logout = () => {
    localStorage.removeItem("access-token");
    localStorage.removeItem("user-role");
    localStorage.removeItem("user-id");
    localStorage.removeItem("current-location")

    setIsLoggedIn(false);
    setIsAdmin(false);
    setUserId(null);
  };

  const values = {
    isLoggedIn,
    isAdmin,
    register,
    login,
    logout,
    userId,
    currentLocation,
    setCurrentLocation,
  };

  return <AuthContext.Provider value={values}>{children}</AuthContext.Provider>;
};

export const useAuthContext = () => useContext(AuthContext);
