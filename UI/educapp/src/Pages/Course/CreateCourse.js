import React, { useState } from 'react';
import axios from 'axios';
import { keycloak, initKeycloak } from "../../keycloak";

function CreateCourse() {
  // const [courseTitle, setCourseTitle] = useState('');
  // const [description, setDescription] = useState('');
  // const [syllabus, setSyllabus] = useState('');
  // const [duration, setDuration] = useState('');
  // //const [category, setCategory] = useState('');
  // const [difficulty, setDifficulty] = useState('Beginner');
  // const [videosUrl, setVideosUrl] = useState(''); // State for Videos URL as a textarea
  const [message, setMessage] = useState('');
const [newCourse, setNewCourse] = useState({
      title: '',
      description: '',
      syllabus: '',
      duration: '',
      difficulty: 'Beginner',
      videosUrl: '',
      imageUrl:''
    });

    const handleInputChange = (e) => {
      const { id, value } = e.target;
      setNewCourse((prevCourse) => ({
        ...prevCourse,
        [id]: value,
      }));
    };

  const handleSubmit = async (event) => {
    event.preventDefault();

    

    try {
      const token = keycloak.token;
      const response = await axios.post(
        'https://localhost:7025/course/create-course',
        newCourse, // The data to be sent in the request body
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      
      if (response.status === 201) {
        setMessage('Course created successfully!');
      } else {
        setMessage('Failed to create course. Please try again.');
      }

      // Clear form after submission
      setNewCourse({
        title: '',
        description: '',
        syllabus: '',
        duration: '',
        difficulty: 'Beginner',
        videosUrl: '',
        imageUrl:''
      });

      // // Clear form after submission
      // setCourseTitle('');
      // setDescription('');
      // setSyllabus('');
      // setDuration('');
      // //setCategory('');
      // setDifficulty('Beginner');
      // setVideosUrl(''); // Clear the new field as well
    } catch (error) {
      console.error('Error creating course:', error);
      setMessage('An error occurred while creating the course. Please try again.');
    }
  };

  return (
    <div className="create-course-container">
      <h2>Create a New Course</h2>
      <form onSubmit={handleSubmit}>

        <div className="form-group">
          <label htmlFor="title">Course Title</label>
          <input
            type="text"
            id="title"
            value={newCourse.title}
            onChange={handleInputChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="description">Description</label>
          <textarea
            id="description"
            value={newCourse.description}
            onChange={handleInputChange}
            required
          ></textarea>
        </div>

        <div className="form-group">
          <label htmlFor="syllabus">Syllabus</label>
          <textarea
            id="syllabus"
            value={newCourse.syllabus}
            onChange={handleInputChange}
            required
          ></textarea>
        </div>

        <div className="form-group">
          <label htmlFor="duration">Duration (in hours)</label>
          <input
            type="number"
            id="duration"
            value={newCourse.duration}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="Price">Price (in $)</label>
          <input
            type="number"
            id="Price"
            value={newCourse.Price}
            onChange={handleInputChange}
            required
          />
        </div>

        {/* <div className="form-group">
          <label htmlFor="category">Category</label>
          <input
            type="text"
            id="category"
            value={category}
            onChange={(e) => setCategory(e.target.value)}
            required
          />
        </div> */}

        <div className="form-group">
          <label htmlFor="difficulty">Difficulty Level</label>
          <select
            id="difficulty"
            value={newCourse.difficulty}
            onChange={handleInputChange}
            required
          >
            <option value="Beginner">Beginner</option>
            <option value="Intermediate">Intermediate</option>
            <option value="Advanced">Advanced</option>
          </select>
        </div>

        <div className="form-group">
          <label htmlFor="Url">Videos URL</label>
          <textarea
            id="Url"
            value={newCourse.Url}
            onChange={handleInputChange}
            required
          ></textarea>
        </div>

        <div className="form-group">
          <label htmlFor="imageUrl">Image URL</label>
          <textarea
            id="imageUrl"
            value={newCourse.imageUrl}
            onChange={handleInputChange}
            required
          ></textarea>
        </div>

        <button type="submit" className="submit-button">Create Course</button>

        {/* Display success or error message */}
        {message && <p className="message">{message}</p>}
      </form>
    </div>
  );
}

export default CreateCourse;
