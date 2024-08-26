import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';

function EnrolleCourse() {
  const { courseId } = useParams(); // Get the courseId from the URL
  const [course, setCourse] = useState(null);

  useEffect(() => {
    const fetchCourse = async () => {
      try {
        const response = await axios.get(`https://localhost:7025/course/${courseId}`);
        setCourse(response.data);
      } catch (error) {
        console.error('Error fetching course details:', error);
      }
    };

    fetchCourse();
  }, [courseId]);

  if (!course) {
    return <p>Loading course details...</p>;
  }

  return (
    <div className="course-details">
      <h2>{course.title}</h2>
      <p>{course.description}</p>

      {/* Display the video */}
      <div className="video-container">
        <iframe
          width="560"
          height="315"
          src={course.Url}
          title={course.title}
          frameBorder="0"
          allowFullScreen
        ></iframe>
      </div>
    </div>
  );
}

export default EnrolleCourse;
