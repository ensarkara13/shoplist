import { Navigate } from "react-router-dom";
import { useAuthContext } from "../contexts/authContext";
import { ShopListProvider } from "../contexts/shopListContext";

function ProtectedRoute({ children }) {
  const { isLoggedIn } = useAuthContext();

  if (!isLoggedIn) {
    return <Navigate to={"/"} />;
  }
  return <ShopListProvider>{children}</ShopListProvider>;
}

export default ProtectedRoute;
