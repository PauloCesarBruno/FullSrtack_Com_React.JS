import { useState } from 'react';
import { Button, FormControl, InputGroup } from 'react-bootstrap'
import TitlePage from '../../components/TitlePage'
import { useNavigate } from 'react-router-dom';

/* ATENÇÃO ESTA PARTE NÃO FIZ PARA SER CONSUMIDA POR NENHUMA API,
 TRATA-SE DE APENAS UM FAKE (MOCK) PARA A DIDATICA DE ROTAS..., NO
 ENTANTO NÃO HAVERA FUNCIONALIDADE DEPENDENTE DE BACKEND, SERVINDO
 APENAS PARA TESTE DE ROTAS E OUTRAS COISASINHAS (rS..) .*/


const clientes = [
  {
    id: 1,
    nome: 'Microsoft',
    responsavel: 'Otto',
    contato: '98546-9522',
    situacao: 'Ativo',
  },
  {
    id: 2,
    nome: 'Amazon',
    responsavel: 'Carla',
    contato: '99322-2501',
    situacao: 'Desativado',
  },  
  {
    id: 3,
    nome: 'Google',
    responsavel: 'Silvana',
    contato: '97253-5566',
    situacao: 'Em Análize',
  },
  {
    id: 4,
    nome: 'Apple',
    responsavel: 'Marcio',
    contato: '99945-5875',
    situacao: 'Ativo',
  },
  {
    id: 5,
    nome: 'Meta',
    responsavel: 'Carlos',
    contato: '99213-4522',
    situacao: 'Ativo',
  },
];

export default function ClienteLista() {
  // Hook´s
  const navigate = useNavigate();
  const [termoBusca, setTermoBusca] = useState('');

  const handleInputChange = (e) => {
    setTermoBusca(e.target.value);
  };

  const clientesFiltrados = clientes.filter((cliente) => {
      return Object.values(cliente)
        .join(' ')
        .toLowerCase()
        .includes(termoBusca.toLowerCase());      
  });

  const novoCliente = () => {
      navigate  ('/cliente/detalhe');
  };
  
  return (
    <>   
     <TitlePage title='Cliente Lista'>  
      <Button variant='outline-secondary' onClick={novoCliente}>
        <i className='fas fa-plus me-2' ></i>
        Novo Cliente
      </Button>
     </TitlePage> 
              <InputGroup className="mt-3 mb-3">
                  <InputGroup.Text>Buscar:</InputGroup.Text>
                  <FormControl
                  onChange={handleInputChange}
                  placeholder='Busca Inteligente'
                  />
                </InputGroup>
        <table className="table table-striped table-hover">
          <thead className='table-dark mt-3'>
            <tr>  
              <th scope="col">#</th>
              <th scope="col">Nome</th>
              <th scope="col">Responsavel</th>
              <th scope="col">Contato</th>
              <th scope="col">Situação</th>
              <th scope="col">Opções</th>
            </tr>
          </thead>
          <tbody>
            {clientesFiltrados.map((cliente) => (
            <tr key={cliente.id}>
              <td>{cliente.id}</td>
              <td>{cliente.nome}</td>
              <td>{cliente.responsavel}</td>
              <td>{cliente.contato}</td>
              <td>{cliente.situacao}</td>              
              <td>
                <div>
                  <button 
                  className="btn btn-sm btn-outline-primary me-2"
                  onClick={() => navigate(
                    `/cliente/detalhe/ ${cliente.id}`
                  )}>
                    <i className='fas fa-user-edit me-2'></i>
                    Editar
                  </button>

                  <button className="btn btn-sm btn-outline-danger me-2">
                  <i className='fas fa-user-times me-2'></i>
                    Desativar
                  </button>
                </div>
              </td>
            </tr>            
            ))}
          </tbody>
        </table>
    </>
  )
}
