import { mount } from '@vue/test-utils';
import { shallowMount } from '@vue/test-utils';
import moxios from 'moxios';

import Detail from '../../src/components/Detail.vue';

describe('Detail.vue', ()=> {

  beforeEach(() => {
    moxios.install()
  })

  afterEach(() => {
    moxios.uninstall()
  })

  test('should show loading indicator', () => {
    const wrapper = mount(Detail, { propsData: { loading: true, title: 'Test'}});
    var loader = wrapper.find('.loader');
    expect(loader.isVisible()).toBe(true);
    var movieDetail = wrapper.find('.t-movie-detail');
    expect(movieDetail.exists()).toBe(false);
  });

  test('should hide loading indicator', (done) => {
    var title = 'Superman'
    const wrapper = shallowMount(Detail, { propsData: { loading: true, title: title}});
    
    moxios.stubRequest('/api/movieDetail/?title=' + title, {
      status: 200,
      response: {"localTitle":"Superman","productionYear":"1978","contentRating":"PG","runningTime":140,"overview":"Superman movie.","genres":["Animation","Action","Adventure","Sci-Fi"],"actors":["Christopher Reeve","Marlon Brando","Margot Kidder","Gene Hackman"],"coverArt":"/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAIBAQIBAQICAgICAgICAwUDAwM"}
    });
    
    moxios.wait(() => {
      expect(wrapper.vm.loading).toBe(false);
      var loader = wrapper.find('.loader');
      expect(loader.exists()).toBe(false);
      var movieDetail = wrapper.find('.t-movie-detail');
      expect(movieDetail.isVisible()).toBe(true);
      done();
    });
  });

  test('should set data on mount', (done) => {
    var title = 'Superman'
    const wrapper = shallowMount(Detail, { propsData: { loading: true, title: title}});
    
    moxios.stubRequest('/api/movieDetail/?title=' + title, {
      status: 200,
      response: {"localTitle":"Superman","productionYear":"1978","contentRating":"PG","runningTime":140,"overview":"Superman movie.","genres":["Animation","Action","Adventure","Sci-Fi"],"actors":["Christopher Reeve","Marlon Brando","Margot Kidder","Gene Hackman"],"coverArt":"/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAIBAQIBAQICAgICAgICAwUDAwM"}
    });
    
    moxios.wait(() => {
      expect(wrapper.vm.movieDetail.localTitle).toEqual('Superman');
      expect(wrapper.vm.status).toBe('Data loaded');
      expect(wrapper.vm.loading).toBe(false);
      done();
    });
  });

  test('should set error status', (done) => {
    var title = 'Superman'
    const wrapper = shallowMount(Detail, { propsData: { loading: true, title: title}});
    
    moxios.stubRequest('/api/movieDetail/?title=' + title, {
      status: 400,
      response: {"message": "oh no"}
    });
    
    moxios.wait(() => {
      expect(wrapper.vm.movieDetail).toEqual({});
      expect(wrapper.vm.status).toEqual('Unexpected error occurred while retrieving Movie Details');
      expect(wrapper.vm.loading).toBe(false);
      done();
    });
  });

});
