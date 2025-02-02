import React, { Component } from 'react'
import CategoryService from '../services/category-service';
import { withNavigation } from './with-navigation';


class CategoryCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    parent_id: '' ,
                
                    name: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeParentIdHandler = this.changeParentIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                        this.saveOrUpdateCategory = this.saveOrUpdateCategory.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Category componentDidMount() ID= " + this.state.id )
            CategoryService.getCategoryById(this.state.id).then( (res) =>{
                let category = res.data;
                this.setState({

                            id: category.id ,
                        
                            parent_id: category.parent_id ,
                        
                            name: category.name 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateCategory = (e) => {
        e.preventDefault();
        let category = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    parent_id: this.state.parent_id , 
                            
                    name: this.state.name  
                        };
        console.log('category => ' + JSON.stringify(category));

        // step 5
        if(this.state.id === '_add'){
            CategoryService.createCategory(category).then(res =>{
                this.props.navigate('/category');
            });
        }else{
            CategoryService.updateCategory(category, this.state.id).then( res => {
                this.props.navigate('/category');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeParentIdHandler= (event) => {
            this.setState({parent_id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({name: event.target.value});
        }
            cancel(){
        this.props.navigate('/category');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Category</h3>
        }else{
            return <h3 className="text-center">Update Category</h3>
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
                                            <label> Parent: </label>
                                            <input placeholder="" name="parent_id" className="form-control" 
                                                value={this.state.parent_id} onChange={this.changeParentIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Name: </label>
                                            <input placeholder="" name="name" className="form-control" 
                                                value={this.state.name} onChange={this.changeNameHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateCategory}>Save</button>
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

export default withNavigation(CategoryCreateComponent);