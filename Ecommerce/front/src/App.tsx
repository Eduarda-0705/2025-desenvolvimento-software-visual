import React from 'react';
import ListarProdutos from './componentes/pages/produto/ListarProdutos';
import CadastrarProduto from './componentes/pages/produto/CadastrarProduto';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Link } from 'react-router-dom';

//Componentes
// - HTML, CSS e JS ou TS
function App() {
  return (
    <div id="api">
      <BrowserRouter>
      <nav>
        <ul>
          <li><Link to="/">Listar Produtos</Link>
          </li>
          <li><Link to="/produto/cadastrar">Cadastrar Produtos</Link>
          </li>
        </ul>
      </nav>
      <Routes>
        <Route path="/" element={<ListarProdutos/>} />
        <Route path="/produto/cadastrar" element={<CadastrarProduto/>} />
      </Routes>
      <footer>
        Rodapé da Aplicação
      </footer>
      </BrowserRouter>
    </div>
  );
}

export default App;
