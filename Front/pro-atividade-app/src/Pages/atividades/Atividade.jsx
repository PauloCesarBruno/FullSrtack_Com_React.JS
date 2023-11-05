/* eslint-disable no-lone-blocks */
import { useEffect, useState } from 'react';
import { Button, Modal} from 'react-bootstrap';
import AtividadeForm     from './AtividadeForm';
import AtividadeLista from './AtividadeLista';
import api from '../../api/atividades';
import TitlePage from '../../components/TitlePage';


export default function Atividade() {
  const [showAtividadeModal, setShowAtividadeModal] = useState(false);
  const [smShowConfirmModal, setSmShowConfirmModal] = useState(false);
  const [atividades, setAtividades] = useState([]);    
  const [atividade, setAtividade] = useState({id: 0});

  const handleAtividadeModal = () => 
  setShowAtividadeModal(!showAtividadeModal); // Funciona Tipo um Interruptor para abrir e fechar o MODAL.

  const handleConfirmModal = (id) =>  {
    if (id !== 0 && id !== undefined) {
      const atividade = atividades.filter((atividade) => atividade.id === id);
      setAtividade(atividade[0]);
    }
    else{
      setAtividade({id:0})
    }
    setSmShowConfirmModal(!smShowConfirmModal); 
  };

  useEffect(() => {
    const getAtividades = async () => {
      const todasAtividades = await PegaTodasAtividades();
      if  (todasAtividades) setAtividades(todasAtividades);
    };
    getAtividades()
  }, [])

  const cancelarAtividade = () => {
    setAtividade({id: 0});
    handleAtividadeModal();
  };

  //=======================================================================================//
  //CRUD:

  const pegarAtividade = (id) => {
    const atividade = atividades.filter((atividade) => atividade.id === id);
    setAtividade(atividade[0]);
    handleAtividadeModal()
  };

    const PegaTodasAtividades = async () => {      
      const response = await api.get('atividade');
      return response.data;
    };

    const novaAtividade = () => {
      setAtividade({id: 0});
      handleAtividadeModal();
    };    

  const addAtividade = async (ativ) => {  
    handleAtividadeModal();
    const response = await api.post('atividade', ativ);
    setAtividades([...atividades, response.data]);
  };  

  const atualizarAtividade = async (ativ) =>{
    handleAtividadeModal();
    const response = await api.put(`atividade/${ativ.id}`, ativ);
    const { id } = response.data;
    setAtividades(
      atividades.map(item => item.id === id ? response.data : item)
    );
    setAtividade({id: 0})
  };

  const deletarAtividade = async (id) => {
    handleConfirmModal(0);
    if (await api.delete(`atividade/${id}`))
    {
      const atividadesFiltradas = atividades.filter(
        (atividade) => atividade.id !== id
      );
      setAtividades([...atividadesFiltradas]);
    }    
  };
  
  // FINAL DO CRUD
  //====================================================================================//
  
  // Abaixo do Retur CDN do BootSwatch...  
  return (
    <>    
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootswatch@4.6.0/dist/cosmo/bootstrap.css"></link>

    <TitlePage
        title={'Atividade ' + (atividade.id !== 0 ? atividade.id : '')}
     >
        <Button variant="outline-secondary" onClick={novaAtividade}>
            <i className='fas fa-plus'></i>
        </Button>
    </TitlePage>
   
        <br/>
        <AtividadeLista
            atividades={atividades}          
            pegarAtividade = {pegarAtividade}
            handleConfirmModal ={handleConfirmModal}
        />
      <br/>  
      <Modal show={showAtividadeModal} onHide={handleAtividadeModal}>
        <Modal.Header closeButton>
          <Modal.Title>
          <h2 className='m-0 p-0'>Atividade {atividade.id !== 0 ? atividade.id : ''}</h2>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <AtividadeForm
              addAtividade={addAtividade}
              cancelarAtividade={cancelarAtividade}
              atualizarAtividade = {atualizarAtividade}
              ativSelecionada ={atividade}
              atividades ={atividades}
          />
        </Modal.Body>       
      </Modal>  

      <Modal
      size="sm"
      show={smShowConfirmModal}
      onHide={handleConfirmModal}
      >
      
      <Modal.Header closeButton>
          <Modal.Title>
          Excluindo Atividade {' '}
          {atividade.id !== 0 ? atividade.id : ''}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Tem certeza de que realmente quer excluir esta atividade {atividade.id} ?
        </Modal.Body>  
        <Modal.Footer>
          <button className="btn btn-outline-success me-2" 
          onClick={() => deletarAtividade(atividade.id)}
          >
            <i className="fas fa-check me-2"></i>
            Sim
          </button>

          <button className="btn btn-danger me-2"
                  onClick={() => handleConfirmModal(0)}
          >
          <i className="fas fa-times me-2"></i>
            Não
          </button>
        </Modal.Footer>     
      </Modal>      
    </>
  );
}
