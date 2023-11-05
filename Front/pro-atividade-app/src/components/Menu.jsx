import React from 'react'
import { NavLink } from 'react-router-dom';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';


export default function Menu() {
  return (
    <>
     <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootswatch@4.6.0/dist/cosmo/bootstrap.css"></link>
    <Navbar bg="dark" expand="lg" variant="dark">
      <Container>
        <Navbar.Brand as={NavLink} to="/">Home</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">            
            <Nav.Link clasname={(navData) => navData.isActive ? 'Active' : ''} as={NavLink} to='/cliente/lista'>Clientes</Nav.Link>
            <Nav.Link Clasname={(navData) => navData.isActive ? 'Active' : ''} as={NavLink} to='/atividade/lista'>Atividades</Nav.Link>
          </Nav>
          <Nav>
            <NavDropdown align='end' title="Paulo Bruno" id="basic-nav-dropdown">
              <NavDropdown.Item href="#action/3.1">Perfil</NavDropdown.Item>             
              <NavDropdown.Item href="#action/3.3">Configurações</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action/3.4">
                Sair
              </NavDropdown.Item>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
    </>
  );
}