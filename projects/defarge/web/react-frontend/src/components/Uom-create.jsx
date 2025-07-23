import React, { Component } from 'react'
import UomService from '../services/uom-service';
import { withNavigation } from './with-navigation';


class UomCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    Name: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                        this.saveOrUpdateUom = this.saveOrUpdateUom.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Uom componentDidMount() ID= " + this.state.id )
            UomService.getUomById(this.state.id).then( (res) =>{
                let uom = res.data;
                this.setState({

                            id: uom.id ,
                        
                            Name: uom.Name 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateUom = (e) => {
        e.preventDefault();
        let uom = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    Name: this.state.Name  
                        };
        console.log('uom => ' + JSON.stringify(uom));

        // step 5
        if(this.state.id === '_add'){
            UomService.createUom(uom).then(res =>{
                this.props.navigate('/uom');
            });
        }else{
            UomService.updateUom(uom, this.state.id).then( res => {
                this.props.navigate('/uom');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({Name: event.target.value});
        }
            cancel(){
        this.props.navigate('/uom');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Uom</h3>
        }else{
            return <h3 className="text-center">Update Uom</h3>
        }
    }
    render() {
        return (
            <div>
                <br></br>
                   <div className = "container">
                        <div className = "row">
                            <div className = "card col-md-6 offset-md-3 offset-md-3">
                                {
                                    this.getTitle()
                                }
                                <div className = "card-body">
                                    <form>
                                        
                    
                                            <div className = "form-group">
                                            <br/>
                                            <label> ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Name: </label>
                                            <input placeholder="" name="Name" className="form-control" 
                                                value={this.state.Name} onChange={this.changeNameHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateUom}>Save</button>
                                        <button className="btn btn-danger" onClick={this.cancel.bind(this)} style={{marginLeft: "10px"}}>Cancel</button>
                                    </form>
                                </div>
                            </div>
                        </div>

                   </div>
            </div>
        )
    }
}

export default withNavigation(UomCreateComponent);