import React, {Component} from 'react'
import { Table } from 'react-bootstrap'

//import axios from "axios"



class TableOut extends Component {

    constructor() {
        super()
        this.state = {
            data: [],
            isLoading: true
        }
    }

    componentDidMount() { 
        fetch("https://localhost:44311//api/Employee", { method: "GET" })
            .then(response => response.json())
            .then(data => {

                this.setState({
                    data: data 
                })
                this.setState({ isLoading: false }) 
            })
    }



    render() {

        if (!this.isLoading) {
            const rows = this.state.data.map(x => <tr key={x.Id}>
                                                  <td>{x.Name}</td>
                                                  <td>{x.Role}</td>
                                                  <td>{x.Birth}</td>
                                                  <td>{x.Team.Name}</td> </tr>)

            return (
             <div>
                    <br/>
                    <br/>
                    <div className= "row" >

                        <div style={{textAlign:'center', marginLeft:'35%'}}>
                               <Table striped bordered hover  >
                                 <thead >
                                     <tr style={{backgroundColor:'orange', color:'darkslategray'}}>
                                         <th> Name</th>
                                         <th> Role</th>
                                         <th> Birth</th>
                                         <th> Team</th>
                                     </tr>
                                 </thead>
                                 <tbody>
                                     {rows}
                                 </tbody>
                             </Table>
                      </div>       
                 </div>             
            </div>
            )
        }


        else {
            return (
                <h1> Loading</h1> 
            )
        }

    }
}



export default TableOut