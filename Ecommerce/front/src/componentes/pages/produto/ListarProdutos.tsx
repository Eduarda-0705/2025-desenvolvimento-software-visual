import { useEffect, useState } from "react";
import Produto from "../../../models/Produto";
import axios from "axios";
import { Link } from "react-router-dom";
//Componente
// - Composto por HTML, CSS e JS ou TS.

//Regras para ser um componente
// - Precisa ser uma função
// - Precisa retornar apenas um elemento HTML pai
// - Exportar o componente

function ListarProdutos(){

    //Estados - São as nossas Variáveis entenda produtos como um get, por exemplo.
    const [produtos, setProdutos] = useState<Produto[]>([]);
    
    // Realiza operações ao carregar o componente 
    useEffect(() => {
        console.log("O componente foi carregado!");
        buscarProdutosAPI();
    }, []);

    async function buscarProdutosAPI(){
        try {
             const resposta = await axios.get("http://localhost:5244/api/produto/listar");
             setProdutos(resposta.data);
        } catch (error) {
            console.log("Erro na requisição: " + error);
        }
        
    }

    async function deletarProduto(id : string){
        // alert("Cliquei no botão");
        // alert(id);
         try {
             const resposta = await axios.delete(`http://localhost:5244/api/produto/remover/${id}`);
             buscarProdutosAPI();
        } catch (error) {
            console.log("Erro ao deletar o produto: " + error);
        }
        
    }


//O return é a parte visual do componente
    return(
       <div id="listar_produtos">
        <h1>Listar Produtos</h1>
        <table>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Nome</th>
                    <th>Descrição</th>
                    <th>Quantidade</th>
                    <th>Preço</th>
                    <th>Criado Em</th>
                    <th>Deletar</th>
                    <th>Alterar</th>
                </tr>
            </thead>
            <tbody>
                 {produtos.map((produto) => (
                 <tr key={produto.id}>
                    <td>{produto.id}</td>
                    <td>{produto.nome}</td>
                    <td>{produto.descricao}</td>
                    <td>{produto.quantidade}</td>
                    <td>{produto.preco}</td>
                    <td>{produto.criadoEm}</td>
                    <td><button onClick={() => deletarProduto(produto.id!)}>Deletar</button></td>
                    <td>
                        <Link to={`/produto/alterar/${produto.id}`}>Alterar</Link>
                    </td>
                 </tr>
        ))}
            </tbody>
        </table>

        <ul>
         </ul>
       </div> 
    );
}

//Esse é o componete que está sendo exportado/basicamente se vc exporta ele tá publico
export default ListarProdutos;
