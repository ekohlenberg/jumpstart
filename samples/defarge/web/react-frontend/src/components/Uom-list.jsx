import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import UomService from '../services/uom-service';

class UomListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                uoms: []
        }
        this.addUom = this.addUom.bind(this);
        this.editUom = this.editUom.bind(this);
        this.deleteUom = this.deleteUom.bind(this);
    }

    deleteUom(id){
        UomService.deleteUom(id).then( res => {
            this.setState({ uoms: this.state.uoms.filter(uom => uom.id !== id) });
        });
    }
    viewUom(id){
        this.props.navigate(`/view-uom/${id}`);
    }
    editUom(id){
        console.log("editing " + id)
        this.props.navigate(`/add-uom/${id}`);
    }

    componentDidMount(){
        UomService.getUoms().then((res) => {
            this.setState({ uoms: res.data});
        });
    }

    addUom(){
        this.props.navigate('/add-uom/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Uom List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addUom}> Add Uom</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>ID</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.uoms.map(
                                        uom => 
                                        <tr key = { uom.id }>

                                                <td> { uom.id } </td>  
                                                
                                                <td> { uom.Name } </td>  
                                                
                                                <td> { uom.is_active } </td>  
                                                
                                                <td> { uom.created_by } </td>  
                                                
                                                <td> { uom.last_updated } </td>  
                                                
                                                <td> { uom.last_updated_by } </td>  
                                                
                                                <td> { uom.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editUom(uom.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteUom(uom.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(UomListComponent);