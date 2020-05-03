package model;

import java.io.Serializable;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "school")
@XmlAccessorType(XmlAccessType.FIELD)
public class schools implements Serializable{
    private static int nextID;
    @XmlElement
    private int school_ID;
    @XmlElement
    private String country;
    @XmlElement
    private String city;
    @XmlElement
    private int zipCode;
    @XmlElement
    private String address;
    @XmlElement
    private int numberOfChildren;

    public schools() {
        this.school_ID = nextID++;
    }

    public int getSchool_ID() {
        return school_ID;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }
    
    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public int getZipCode() {
        return zipCode;
    }

    public void setZipCode(int zipCode) {
        this.zipCode = zipCode;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public int getNumberOfChildren() {
        return numberOfChildren;
    }

    public void setNumberOfChildren(int numberOfChildren) {
        this.numberOfChildren = numberOfChildren;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 83 * hash + this.school_ID;
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final schools other = (schools) obj;
        if (this.school_ID != other.school_ID) {
            return false;
        }
        return true;
    }
    
    
    
    
    
}
