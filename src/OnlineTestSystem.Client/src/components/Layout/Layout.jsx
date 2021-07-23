import { Container } from "react-bootstrap";
import { NavigationBar } from "./NavigationBar";

export const Layout = ({ children }) => (
  <div>
    <NavigationBar />
    <Container>
      {children}
    </Container>
  </div>
);