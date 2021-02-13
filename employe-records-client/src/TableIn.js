import React,{Component} from 'react'
import CreateEmploye from "./CreateEmploye"
import {Table} from 'react-bootstrap'
import axios from "axios"


class TableIn extends Component {

    constructor() {
        super()
        this.state = {
            data: [],
            isLoading: true,
            property: "",
            min: "",
            max: ""
            

        }
    }

    handleChange = (event) => {
        const { value, name } = event.target
        this.setState({ [name]: value })
    }//setuj vrednost za input u formi

    handleSubmit = (event) => {
        event.preventDefault();
        axios("https://localhost:44311/api/Search/", {
            method: "POST",
            headers: { Authorization: "Bearer " + sessionStorage.getItem("token") },
            data: {
                Min :this.state.min,
                Max: this.state.max
            }
        })
        .then(object => {
            this.setState({
                data: object.data
            })
            this.setState({ isLoading: false })
        })
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

    handleClick = (event) => { 
        axios("https://localhost:44311/api/Employee/" + event.target.name, {
            method: "DELETE",
            headers: { Authorization: "Bearer " + sessionStorage.getItem("token") }
        })
            .then(() => { window.location.reload() }) 
             
       
    }
   
    render() {

        if (!this.isLoading) {
            const rows = this.state.data.map(x => <tr key={x.Id}>
                                                  <td>{x.Name}</td>
                                                  <td>{x.Role}</td>
                                                  <td>{x.Birth}</td>
                                                  <td>{x.Team.Name}</td>
                                                  <td>{x.Salary}</td>
                                                  <td><button onClick={this.handleClick} className="btn btn-danger" name={x.Id}>Delete</button></td></tr>)

            return (
                <div className='container'>

                     <div className= "row" >

                       <div className='form-horizontal' style={{marginTop:'5%', marginLeft:'5%'}}>
                          <h5 style={{ backgroundColor:'darkslategray', color:'orange', textAlign:'center',marginRight:'10%'}}>Search property by Birth</h5>
                            <form className="form-inline" style={{marginTop:'4%', marginRight:'5%'}}>
                           
                              <label style={{marginRight:'10px',backgroundColor:'orange', color:'darkslategray'}} > <strong> From: </strong> </label>
                              
                                  <input style={{marginRight:'10px', width:'30%'}}
                                         type="number"
                                         placeholder="From quadrature"
                                         className="form-inline"
                                         name="min"
                                         value={this.state.min}
                                         onChange={this.handleChange}
                                />
                           
                          
                               <br/>
                         
                             <label style={{marginRight:'1px', backgroundColor:'orange', color:'darkslategray'}} > <strong> To: </strong> </label>
                         
                                 <input style={{marginLeft:'10px', width:'30%',marginRight:'20px'}}
                                        type="number"
                                        placeholder="To quadrature"
                                        className="form-inline"
                                        name="max"
                                        value={this.state.max}
                                        onChange={this.handleChange}
                               />
                          
                          
                               <br />
                               <button type="submit" className="btn btn-warning"style={{backgroundColor:'orange'}} onClick={this.handleSubmit} >Search</button>
                           
                          </form>
                     </div>
                </div>

                         

                 <div className='row'>

                    
                     <div style={{textAlign:'center', marginTop:'5%'}}> 

                        <h3 style={{ backgroundColor:'darkslategray', color:'orange'}}>Properties</h3>
                          
                            <Table striped bordered hover  >
                                <thead>
                                    <tr style={{backgroundColor:'orange', color:'darkslategray'}}>
                                    <th> Name</th>
                                    <th> Role</th>
                                    <th> Birth</th>
                                    <th> Team</th>
                                    <th> Salary</th>
                                    <th> Option</th>
                                    
                                    </tr>
                                </thead>
                                <tbody>
                                    {rows}
                                </tbody>
                            </Table>
                          
                          

                        </div>
                        {sessionStorage.getItem("token") ? <CreateEmploye /> : null}
                    </div>

                   
                    
                </div>
            )
        }


        else {
            return (
                <h1> Loading </h1>
            )
        }

    }
}



export default TableIn