import { Card, Container } from "react-bootstrap";
import { NavigationBar } from "./NavigationBar";

export const Layout = ({ children }) => (
  <div>
    <NavigationBar />
    <Container>
      <Card className="my-3">
        <Card.Body>
          {children}
        </Card.Body>
      </Card>
    </Container>
  </div>
);