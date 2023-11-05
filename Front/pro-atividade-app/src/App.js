import './App.css';
import Atividade from "./Pages/atividades/Atividade";
import { Routes, Route } from 'react-router-dom';
import Cliente from './Pages/clientes/Cliente';
import Dashboard from './Pages/dashboard/Dashboard';
import Clienteform from './Pages/clientes/ClienteForm';
import PageNotFound from './Pages/PageNotFound';

export default function App() {
  
  return (
        <Routes>      
          <Route path='/' element={<Dashboard />} />
          <Route path='/atividade/*' element={<Atividade />} />
          <Route path='/atividade/:id/cliente' element={<Cliente />} />
          <Route path='/cliente/*' element={<Cliente />} />
          <Route path='/cliente/:id/atividade' element={<Atividade />} />
          <Route path='/cliente/detalhe/' element={<Clienteform />} />
          <Route path='/cliente/detalhe/:id' element={<Clienteform />} />
          <Route element={<PageNotFound />} />
        </Routes>
    );  
} 

