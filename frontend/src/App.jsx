import { Container } from "@chakra-ui/react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Navbar from "./components/Navbar";
import LoginPage from "./pages/Auth/LoginPage";
import RegisterPage from "./pages/Auth/RegisterPage";
import DashboardPage from "./pages/DashboardPage";
import NotFoundPage from "./pages/NotFoundPage";
import ShopListsPage from "./pages/ShopListsPage";
import AnonymousRoute from "./routes/AnonymousRoute";
import ProtectedRoute from "./routes/ProtectedRoute";

function App() {
  return (
    <BrowserRouter>
      <Navbar />
      <Container maxW={"container.xl"}>
        <Routes>
          <Route path="/">
            <Route
              index
              element={
                <AnonymousRoute>
                  <LoginPage />
                </AnonymousRoute>
              }
            />
            <Route
              path="register"
              element={
                <AnonymousRoute>
                  <RegisterPage />
                </AnonymousRoute>
              }
            />
            <Route
              path="dashboard"
              element={
                <ProtectedRoute>
                  <DashboardPage />
                </ProtectedRoute>
              }
            />
            <Route
              path="shoplists"
              element={
                <ProtectedRoute>
                  <ShopListsPage />
                </ProtectedRoute>
              }
            />
          </Route>
          <Route path="*" element={<NotFoundPage />} />
        </Routes>
      </Container>
    </BrowserRouter>
  );
}

export default App;
