import { Link, useNavigate } from "react-router-dom";
import { Button, Text } from "@chakra-ui/react";
import { useAuthContext } from "../contexts/authContext";

function Navbar() {
  const { isLoggedIn, isAdmin, logout } = useAuthContext();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate("/");
  };

  return (
    <nav className="nav">
      <div className="left">
        <div className="logo">
          <Link to={isLoggedIn ? "/dashboard" : "/"}>Alışveriş Listesi</Link>
        </div>

        {isLoggedIn && !isAdmin && (
          <ul className="menu">
            <li>
              <Link to={"shoplists"}>
                <Text color={"gray.300"}>Listelerim</Text>
              </Link>
            </li>
          </ul>
        )}
      </div>

      <div className="right">
        {!isLoggedIn && (
          <>
            <Link to="/register">
              <Button colorScheme="blue">Kayıt Ol</Button>
            </Link>
            <Link to="/">
              <Button colorScheme="blue">Giriş Yap</Button>
            </Link>
          </>
        )}

        {isLoggedIn && isAdmin && (
          <Button colorScheme="orange" m={"2"}>
            Admin
          </Button>
        )}

        {isLoggedIn && (
          <Button colorScheme="red" onClick={handleLogout}>
            Çıkış Yap
          </Button>
        )}
      </div>
    </nav>
  );
}

export default Navbar;
