import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';

const CourseDetails = () => {
  const { courseId } = useParams(); // Get course ID from URL
  const [course, setCourse] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchCourseDetails = async () => {
      try {
        const response = await axios.get(`https://localhost:7025/api/FirasCourseApi/courses/${courseId}`);
        setCourse(response.data);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching course details:', error);
        setLoading(false);
      }
    };

    fetchCourseDetails();
  }, [courseId]);

  if (loading) {
    return <p>Loading course details...</p>;
  }

  if (!course) {
    return <p>Course not found</p>;
  }

  return (
    <div className="course-details-container">
      <h2>{course.title}</h2>
      <img src={course.imageUrl} alt={course.title} className="course-image" />
      <p><strong>Description:</strong> {course.description}</p>
      <p><strong>Syllabus:</strong> {course.syllabus}</p>
      <p><strong>Duration:</strong> {course.duration} hours</p>
      <p><strong>Difficulty:</strong> {course.difficulty}</p>
      <p><strong>Price:</strong> ${course.price}</p>
      <button className="enroll-button">Enroll in this course</button>
    </div>
  );
};

export default CourseDetails;
