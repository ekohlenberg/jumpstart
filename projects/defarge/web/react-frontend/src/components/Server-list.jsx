import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import ServerService from '../services/server-service';

class ServerListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                servers: []
        }
        this.addServer = this.addServer.bind(this);
        this.editServer = this.editServer.bind(this);
        this.deleteServer = this.deleteServer.bind(this);
    }

    deleteServer(id){
        ServerService.deleteServer(id).then( res => {
            this.setState({ servers: this.state.servers.filter(server => server.id !== id) });
        });
    }
    viewServer(id){
        this.props.navigate(`/view-server/${id}`);
    }
    editServer(id){
        console.log("editing " + id)
        this.props.navigate(`/add-server/${id}`);
    }

    componentDidMount(){
        ServerService.getServers().then((res) => {
            this.setState({ servers: res.data});
        });
    }

    addServer(){
        this.props.navigate('/add-server/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Server List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addServer}> Add Server</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Server ID</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>Type</th>
                                    
                                    <th>Address</th>
                                    
                                    <th>Port</th>
                                    
                                    <th>Is Default</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.servers.map(
                                        server => 
                                        <tr key = { server.id }>

                                                <td> { server.id } </td>  
                                                
                                                <td> { server.name } </td>  
                                                
                                                <td> { server.type } </td>  
                                                
                                                <td> { server.address } </td>  
                                                
                                                <td> { server.port } </td>  
                                                
                                                <td> { server.is_default } </td>  
                                                
                                                <td> { server.is_active } </td>  
                                                
                                                <td> { server.created_by } </td>  
                                                
                                                <td> { server.last_updated } </td>  
                                                
                                                <td> { server.last_updated_by } </td>  
                                                
                                                <td> { server.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editServer(server.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteServer(server.id)} className="btn btn-danger">Delete </button>
                                                
                                             </td>
                                        </tr>
                                    )
                                }
                            </tbody>
                        </table>

                 </div>

            </div>
        )
    }
}

export default withNavigation(ServerListComponent);