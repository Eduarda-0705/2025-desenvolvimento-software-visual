import React from 'react';
import ListarProdutos from './componentes/pages/produto/ListarProdutos';
import CadastrarProduto from './componentes/pages/produto/CadastrarProduto';

//Componentes
// - HTML, CSS e JS ou TS
function App() {
  return (
    <div id="api">
      {/* <h1>Minha primeira aplicação em React!</h1> */}
      <ListarProdutos/>
      <CadastrarProduto/>
    </div>
  );
}

export default App;
