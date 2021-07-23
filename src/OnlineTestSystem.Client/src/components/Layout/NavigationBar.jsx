import { Container, Nav, Navbar, NavDropdown } from "react-bootstrap";
import { Link } from "react-router-dom";
import { useAuth } from "../Account/useAuth";

export const NavigationBar = () => {
    const auth = useAuth();
    return (
        <Navbar bg="light" expand="lg" className="shadow-sm">
            <Container>
                <Navbar.Brand>Online Test System</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <Link to="/" className="nav-link">Tests</Link>
                    </Nav>
                    {auth.user &&
                        <Nav>
                            <NavDropdown title={auth.user?.username} className="active">
                                <li><Link to='/account/logout' className="dropdown-item">Logout</Link></li>
                            </NavDropdown>
                        </Nav>
                    }
                </Navbar.Collapse>

            </Container>
        </Navbar>
    );
}